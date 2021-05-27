//MAP
let tecnologias = new Map()
tecnologias.set('react', {framework: false})
console.log(tecnologias)
tecnologias.delete('react')

//SET (NÃO ACEITA REPETIÇÃO)
let times = new Set()
times.add('Vasco')

//FOR-OF PARA PERCORRER E RECEBER DIRETO OS VALORES, E NÃO ÍNDICES (QUASE O FOREACH DO C#)
let vetor = ['a', 'b', 'c']

for(let letra of vetor)
{
    console.log(letra)
}