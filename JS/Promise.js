let promise = new Promise(function(Resolve){
    Resolve(3)
})

promise.then(valor => console.log(valor))

//RETORNANDO UMA PROMISE
function EsperarPor(tempo = 2000)
{
    return new Promise(function(resolve){
        setTimeout(function(){
            console.log("Executando promise...")
            resolve('Then')
        }, tempo)
    })
}

let p = EsperarPor(3000).then(texto => {
    console.log(texto)
})

//VÁRIAS PROMISES EXECUTADAS ANTES
function VariasPromises()
{
    return Promise.all([EsperarPor(3000), EsperarPor(3000), EsperarPor(3000)])
}

EsperarPor().then(texto => console.log('ALL'))

//PROMISE COM TRATAMENTO DE ERRO
function PromiseComErro(){
    return new Promise((resolve, reject) =>{
        try
        {
            Math.random() >= 0.5 ? resolve('Sucesso') : reject('Erro')
        }catch(exception)
        {
            reject('exception')
        }
    })
}

let p2 = PromiseComErro()
    .then(texto => {console.log(texto)})
    .catch(texto => {console.log(texto)})


//USANDO ASYNC / AWAIT
function EsperarPor2(tempo = 2000)
{
    return new Promise(function(resolve, reject){
        try{
            setTimeout(function(){
                console.log("Executando promise...")
                resolve('Then')
            }, tempo)
        }catch(exception)
        {
            reject('Erro2')
        }
    })
}

async function executar()
{
    try
    {
        await EsperarPor2(1500)
        console.log('executando 1...')
        await EsperarPor2(1500)
        console.log('executando 2...')
    }catch(exception)
    {
        throw "Erro3"
    }
}

executar().catch(erro => console.log(erro))