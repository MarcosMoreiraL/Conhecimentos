const express = require('express')
const app = express()

app.get('/opa', (req, res) => {
    res.json({
        name:'ipad',
        preco: '5000,00'
    })
})

app.listen(3000, () => {
    console.log("Start")
})