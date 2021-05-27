//CRIANDO COM A NOTAÇÃO LITERAL
const obj1 = {}

//OBJECT em JS
const obj2 = new Object

//FUNÇÃO CONSTRUTORA
function Produto(nome, preco, desconto)
{
    this.nome = nome //PÚBLICO
    this.preco = preco //PÚBLICO
    let descontoPrivado = desconto //PRIVADO
}

//FUNÇÃO FACTORY
function CriarFuncionario(nome, cargo, salario)
{
    return{
        nome,
        cargo,
        getSalario()
        {
            return salario
        }
    }
}

//OBJECT.CREATE
const obj3 = Object.create(null) //É PASSADO ALGUM OBJETO PAI COMO PARÂMETRO

//USANDO JSON
const fromJSON = JSON.parse('{"info": "Sou um JSON"}')


//USANDO GETTERS E SETTERS
const obj4 = {
    _valor: 1,
    get valor(){return this._valor},
    set valor(valor){this._valor = valor}
}

//FUNÇÕES IMPORTANTES DE OBJECT
const obj5 = {
    nome: 'Gilmar',
    idade: 18,
    peso: 75
}

console.log(Object.keys(obj5)) //IMPRIME O NOME DAS CHAVES APENAS
console.log(Object.values(obj5)) //IMPRIME OS VALORES APENAS
console.log(Object.entries(obj5)) //GERA UM ARRAY COM OS SUBARRAYS DE ['CHAVE', 'VALOR']

//ADICIONAR UM ATRIBUTO DINAMICAMENTE DEIXANDO ESPECIFICAR PROPRIEDADES
Object.defineProperty(obj5, 'dataDeNascimento', { 
    enumerable: true,
    writable: true,
    value: '25/01/2000'
})

const obj6 = {a: 1}
const obj7 = {b: 2}
let obj8 = {}
obj8 = Object.assign(obj8, obj6, obj7) //CONCATENA VÁRIOS OBJETOS EM UM SÓ

//HERANÇA
let carro = {
    modelo: 'Genérico',
    velMax: 0
}

let ferrari = {
    __proto__: carro,
    cor(){return 'Vermelho'}
}

let uno = {
    __proto__: ferrari,
    velMax: 80,
    cor: 'Azul', //SOBRESCREVI A VARIÁVEL DO PAI
    escada: true
}

let palio = {
    preco: 30000
}
Object.setPrototypeOf(palio, uno) //UNO AGORA É PAI DO PALIO

let fiesta = Object.create(carro) //CRIEI UM OBJETO COM O CARRO COMO PAI

let property = fiesta.hasOwnProperty(fiesta.velMax) //VERIFICANDO SE A PROPRIEDADE É EXCLUSIVA DO FIESTA
console.log(property)

//NÃO DEIXA ADICIONAR NOVOS ATRIBUTOS AO OBJETO MAS AINDA PODE EXCLUIR
let obj9 = Object.preventExtensions({ 
    nome: 'Gilmar'
})

let obj10 = {
    nome: 'Gilmar'
}
Object.seal(obj10) //NÃO DEIXA ADICIONAR NEM EXCLUIR NOVOS ATRIBUTOS

Object.freeze(obj10) //TORNA UM OBJETO CONSTANTE, NÃO PODE ADICIONAR, REMOVER E NEM EDITAR OS VALORES

delete obj10.nome //DELETA UM ATRIBUTO DO OBJETO

//CLASSES
class Classe{
    constructor(nome = 'NovaClasse', valor = 0)
    {
        this.nome = nome
        this.valor = valor
    }
}

//HERANÇA
class Classe2 extends Classe{
    constructor(nome, valor, sobrenome)
    {
        super(nome, valor)
        this.sobrenome = sobrenome
    }
}