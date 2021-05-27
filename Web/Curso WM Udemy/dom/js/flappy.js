function NovoElemento(tagName, className)
{
    const elem = document.createElement(tagName)
    elem.className = className
    return elem
}

function Barreira(reversa = false)
{
    this.elemento = NovoElemento('div', 'barreira')

    const borda = NovoElemento('div', 'borda')
    const corpo = NovoElemento('div', 'corpo')

    this.elemento.appendChild(reversa ? corpo : borda)
    this.elemento.appendChild(reversa ? borda : corpo)

    this.SetAltura = altura => corpo.style.height = `${altura}px`
}

function ParDeBarreiras(altura, abertura, x)
{
    this.elemento = NovoElemento('div', 'par-de-barreiras')
    
    this.superior = new Barreira(true)
    this.inferior = new Barreira(false)

    this.elemento.appendChild(this.superior.elemento)
    this.elemento.appendChild(this.inferior.elemento)

    this.SortearAbertura = () => {
        const alturaSuperior = Math.random() * (altura - abertura)
        const alturaInferior = altura - abertura - alturaSuperior
        this.superior.SetAltura(alturaSuperior)
        this.inferior.SetAltura(alturaInferior)
    }

    this.GetX = () => parseInt(this.elemento.style.left.split('px')[0])
    this.SetX = x => this.elemento.style.left = `${x}px`
    this.GetLargura = () => this.elemento.clientWidth

    this.SortearAbertura()
    this.SetX(x)
}

function Barreiras(altura, largura, abertura, espaco, NotificarPonto)
{
    this.pares = [
        new ParDeBarreiras(altura, abertura, largura),
        new ParDeBarreiras(altura, abertura, largura + espaco),
        new ParDeBarreiras(altura, abertura, largura + espaco * 2),
        new ParDeBarreiras(altura, abertura, largura + espaco * 3)
    ]

    const deslocamento = 3
    this.Animar = () => {
        this.pares.forEach(par => {
            par.SetX(par.GetX() - deslocamento)

            //quando o elemento sair da tela
            if(par.GetX() < -par.GetLargura())
            {
                par.SetX(par.GetX() + espaco * this.pares.length)
                par.SortearAbertura()
            }

            const meio = largura / 2
            const cruzouOMeio = par.GetX() + deslocamento >= meio && par.GetX() < meio
            cruzouOMeio && NotificarPonto() // if(cruzouOMeio) notificarPonto
        })
    }
}

function Passaro(alturaJogo)
{
    let voando = false

    this.elemento = NovoElemento('img', 'passaro')
    this.elemento.src = 'imgs/passaro.png'

    this.GetY = () => parseInt(this.elemento.style.bottom.split('px')[0])
    this.SetY = y => this.elemento.style.bottom = `${y}px`

    window.onkeydown = e => voando = true
    window.onkeyup = e => voando = false

    this.Animar = () =>{
        const novoY = this.GetY() + (voando ? 8 : -5)
        const alturaMaxima = alturaJogo - this.elemento.clientHeight
        if(novoY <= 0)
        {
            this.SetY(0)
        }else if(novoY >= alturaMaxima)
        {
            this.SetY(alturaMaxima)
        }else
        {
            this.SetY(novoY)
        }
    }
    this.SetY(alturaJogo / 2)
}

function Progresso()
{
    this.elemento = NovoElemento('span', 'progresso')
    this.AtualizarPontos = pontos => {
        this.elemento.innerHTML = pontos
    }
    this.AtualizarPontos(0)
}

function EstaoSobrepostos(elementoA, elementoB)
{
    const a = elementoA.getBoundingClientRect()
    const b = elementoB.getBoundingClientRect()

    const horizontal = a.left + a.width >= b.left && b.left + b.width >= a.left
    const vertical = a.top + a.height >= b.top && b.top + b.height >= a.top

    return horizontal && vertical
}

function Colidiu(passaro, barreiras)
{
    let colidiu = false

    barreiras.pares.forEach(parDeBarreiras =>{
        if(!colidiu)
        {
            const superior = parDeBarreiras.superior.elemento
            const inferior = parDeBarreiras.inferior.elemento
            colidiu = EstaoSobrepostos(passaro.elemento, superior) 
            || EstaoSobrepostos(passaro.elemento, inferior)
        }
    })
    return colidiu
}

function FlappyBird()
{
    let pontos = 0

    const areaDoJogo = document.querySelector('[wm-flappy]')
    const altura =  areaDoJogo.clientHeight
    const largura = areaDoJogo.clientWidth

    const progresso = new Progresso()
    const barreiras = new Barreiras(altura, largura, 200, 400, () => progresso.AtualizarPontos(++pontos))
    const passaro = new Passaro(altura)

    areaDoJogo.appendChild(progresso.elemento)
    areaDoJogo.appendChild(passaro.elemento)
    barreiras.pares.forEach(par => areaDoJogo.appendChild(par.elemento))

    this.Start = () => {
        const temporizador = setInterval(() =>{
            barreiras.Animar()
            passaro.Animar()

            if(Colidiu(passaro, barreiras))
            {
                clearInterval(temporizador)
            }
        }, 20)
    }
}

new FlappyBird().Start()