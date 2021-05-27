//SEM TRATAMENTO DE ERRO
function ImprimirMaiusculo(obj)
{
    console.log(obj.name.toUpperCase())
}

const obj = {nome: 'Gilmar'}
ImprimirMaiusculo(obj)

//COM TRATAMENTO DE ERRO
function TratarErroElancar(erro)
{
    //throw new Error('Erro!!') --> recebendo string
    
    throw{ // --> recebendo um Object
        nome: erro.name,
        message: erro.message,
        date: new Date
    }
}

function ImprimirMaiusculo2(obj)
{
    try
    {
        console.log(obj.name.toUpperCase())
    }catch
    {
        TratarErroElancar(erro)
    }finally
    {
        console.log('O Finally é chamado de qualquer jeito')
    }
}

const obj2 = {nome: 'Gilmar'}
ImprimirMaiusculo2(obj)