let pessoas = ['Gilmar', 'Gerson', 'Claudia', 'Julia']

pessoas.shift() //REMOVE O PRIMEIRO ELEMENTO DO ARRAY
pessoas.pop(); //REMOVE O ÚLTIMO ELEMENTO DO ARRAY

pessoas.push('Gilson') //ADICIONA NO FINAL
pessoas.unshift('Vanderlei')  //ADICIONA NO INICIO

//splice(índice de inicio, num de elementos pra apagar, elementos a adicionar)
pessoas.splice(2, 0, 'Jorge', 'Cleiton') 

let algumasPessoas = pessoas.slice(2, 4) //RETORNA UM NOVO ARRAY A PARTIR DO INDICE PASSADO ATÉ O OUTRO ÍNDICE

delete pessoas[0] //DELETA IGUAL A UM OBJETO

pessoas.forEach(function(){}) //PERCORRE O ARRAY E EXECUTA UMA CALLBACK COM CADA ELEMENTO
for(let elemento in pessoas)
{
    console.log('For-in pra percorrer cada elemento do array')
}

let mapeado = pessoas.map(function(elemento){}) //GERA UM ARRAY NOVO DE ACORDO COM A CALLBACK PASSADA

let filtrado = pessoas.filter(function(){}) //GERA UM NOVO ARRAY FILTRADO DE ACORDO COM A CALLBACK

let acumulado = pessoas.reduce(function(){}) //ACUMULA O RESULTADO DE UMA CALLBACK SOBRE UM ARRAY

let maisPessoas = ['Carlos', 'Adailton']
let todoMundo = pessoas.concat(maisPessoas) //CONCATENA ARRAYS

//FLATMAP
Array.prototype.flatMap() = function(callBack){
    return Array.prototype.concat.apply([], this.map(callBack))
}