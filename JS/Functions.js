function ImprimirSoma(a , b)
{
    console.log(a + b)
}
//RETORNO E VALOR PADRÃO DEFINIDO
function SomaComRetorno(a , b = 0)
{
    return a + b
}

ImprimirSoma(2,3)

console.log(SomaComRetorno(2))
//FUNÇÃO ARMAZENADA NA VARIÁVEL
let somaAnonima = function (a , b) {
    console.log(a + b)
}

somaAnonima(2,3)

//ARROW FUNCTION
let soma = (a, b) => {
    return a + b
}

console.log(soma(5 , 6))
//RETORNO IMPLÍCITO
let subtracao = (a , b) => a - b

console.log(subtracao(10, 8))

//FUNCÃO QUE RETORNA FUNÇÃO
function Soma(a, b)
{
    return function (c) {
        console.log(a + b + c)
    }
}

Soma(2 , 3)(4) 
//ARGUMENTOS VARIÁVEIS

function SomaArgs()
{
    let soma = 0
    for(let i in arguments)
    {
        soma+= arguments[i]
    }
    return soma
}

console.log(SomaArgs(10.3, 12.2, 3))

//BIND
var pessoa = {
    saudacao: 'Bom dia!',
    Falar()
    {
        console.log(this.saudacao)
    }
}

pessoa.Falar()

let falar = pessoa.Falar
falar()

//O BIND PASSA O OBJETO PARA SER O THIS NA HORA DA CHAMADA DA FUNÇÃO 
let falarDePessoa = pessoa.Falar.bind(pessoa)
falarDePessoa()

//FUNÇÃO FACTORY SIMPLES
let p1 =  CriarPessoa =>
{
    return{
        nome: 'Ana',
        sobrenome: 'Silva'
    }
}

//FUNÇÃO FACTORY COM PARÂMETROS
let p2 = (nome, preco) =>
{
    return{
        nome,
        preco,
        desconto: 0.1
    }
}

//FUNÇÃO CONSTRUTORA
function Carro(maxSpeed = 200, delta = 5)
{
    let curSpeed = 0

    this.Accelerate = function()
    {
        if(curSpeed + delta < maxSpeed)
        {
            curSpeed+=delta
        }else
        {
            curSpeed = maxSpeed
        }
    }

    this.GetCurSpeed = () => curSpeed; 
}

let uno = new Carro

uno.Accelerate()

console.log(uno.GetCurSpeed())

//IIFE 
(function()
{
    console.log("IIFE")
})()

//CALL E APPLY
function GetPreco(desconto = 0, moeda = 'R$')
{
    return `${moeda} ${this.preco * (1 - desconto)}`
}

let carro = {
    nome: 'Camaro',
    preco: 200000,
    desconto: 0.1,
    GetPreco
}

console.log('Usando o Call: ' + GetPreco.call(carro, carro.desconto, '$'))
console.log('Usando o Apply: ' + GetPreco.apply(carro, [carro.desconto, 'R$']))

function MuitosParametros(...params)
{
    let vetor = []
    params.forEach( x =>{
        vetor.push(x)
    }) 
    return vetor
}