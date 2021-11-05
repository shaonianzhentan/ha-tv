DOMAIN = 'ha_tv'
ROOT_PATH = '/ha-tv'

def setup(hass, config):
    hass.http.register_static_path(ROOT_PATH, hass.config.path("custom_components/" + DOMAIN + "/local"), False)
    return True