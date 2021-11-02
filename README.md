# HomeAssistant电视版


打开电视APP，在浏览器输入`http://192.168.1.116:8124/`
```js
fetch(`?url=${encodeURIComponent("http://192.168.1.112:8080")}`)
.then(res=>res.json()).then(console.log)
```

```js
function setValue(i, value){
    fetch('', {
        method: 'POST',
        body: JSON.stringify({
            js: `
                document.querySelector('ha-authorize').shadowRoot.
                querySelector('ha-auth-flow').shadowRoot.
                querySelector('form').querySelector('ha-form').shadowRoot.
                querySelectorAll('ha-form')[${i}].shadowRoot.
                querySelector('ha-form-string').shadowRoot.querySelector('paper-input').value='${value}'
            `
        }),
        headers: {
            'Content-Type': 'application/json; charset=utf-8'
        }
    }).then(res => res.json()).then(console.log)
}

setValue(0, '用户名')

setValue(1, '密码')
```

```js
fetch('', {
    method: 'POST',
    body: JSON.stringify({
        js: `
            document.querySelector('ha-authorize').shadowRoot.
            querySelector('ha-auth-flow').shadowRoot.
            querySelector('form').querySelector('mwc-button').click()
        `
    }),
    headers: {
        'Content-Type': 'application/json; charset=utf-8'
    }
}).then(res => res.json()).then(console.log)
```