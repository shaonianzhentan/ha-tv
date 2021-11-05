import { getAuth, createConnection, subscribeEntities, getUser, ERR_HASS_HOST_REQUIRED } from "home-assistant-js-websocket";

class Hass {

    constructor() {
        this.hass = null
        this.entities = [
            {
                domain: 'media_player'
            }
        ]
    }

    async connect(hassUrl) {
        let auth;
        try {
            auth = await getAuth({
                loadTokens() {
                    try {
                        return JSON.parse(localStorage["hassTokens"]);
                    } catch { }
                },
                saveTokens: (data) => {
                    localStorage["hassTokens"] = JSON.stringify(data);
                },
            });
        } catch (err) {
            if (err === ERR_HASS_HOST_REQUIRED) {
                auth = await getAuth({ hassUrl });
            } else {
                alert(`Unknown error: ${err}`);
                return;
            }
        }
        const connection = await createConnection({ auth });
        this.hass = connection;
        // 初始化登录信息
        getUser(connection).then((user) => {
            console.log("Logged in as", user);
        });
        // 更新
        subscribeEntities(connection, (ent) => {
            this.entities = Object.keys(ent).map((entity_id) => {
                const { attributes, state } = ent[entity_id];
                // console.log(ent[entity_id]);
                const domain = entity_id.split(".")[0];
                if (!attributes["icon"]) {
                    const icon = {
                        light: {
                            on: "mdi-lightbulb-on-outline",
                            off: "mdi-lightbulb-outline",
                        },
                        switch: {
                            on: "mdi-toggle-switch-outline",
                            off: "mdi-toggle-switch-off-outline",
                        },
                        input_boolean: {
                            on: "mdi-electric-switch",
                            off: "mdi-electric-switch",
                        },
                        fan: {
                            on: "mdi-fan",
                            off: "mdi-fan-off",
                        },
                        script: {
                            on: "mdi-script",
                            off: "mdi-script-outline",
                        },
                        binary_sensor: {
                            on: "mdi-checkbox-blank-circle",
                            off: "mdi-checkbox-blank-circle-outline",
                        },
                        automation: {
                            on: "mdi-robot",
                            off: "mdi-robot-outline",
                        },
                    };
                    let obj = icon[domain];
                    let state_icon = null;
                    if (obj) {
                        state_icon = obj[state];
                    }
                    if (state_icon) {
                        attributes["icon"] = state_icon.replace("mdi:", "mdi-");
                    }
                } else {
                    attributes["icon"] = attributes["icon"].replace("mdi:", "mdi-");
                }
                return {
                    ...attributes,
                    state,
                    entity_id,
                    domain,
                };
            });
        });
    }

    async callService(serviceName, service_data = {}) {
        let arr = serviceName.split(".");
        const result = await this.hass.sendMessagePromise({
            type: "call_service",
            domain: arr[0],
            service: arr[1],
            service_data,
        });
        return result;
    }

    toggle({ domain, entity_id, state }) {
        this.callService(`${domain}.turn_${state == "on" ? "off" : "on"}`, { entity_id });
    }

    media_play_pause({ entity_id }) {
        this.callService('media_player.media_play_pause', { entity_id });
    }

    media_next_track({ entity_id }) {
        this.callService('media_player.media_next_track', { entity_id });
    }

    media_previous_track({ entity_id }) {
        this.callService('media_player.media_previous_track', { entity_id });
    }
}

export default {
    install: function (Vue) {
        Vue.hass = Vue.prototype.hass = new Hass()
    }
}