const gulp = require('gulp')
const {series, parallel} = require('gulp')

const Antes1 = cb => {
    console.log('Tarefa Antes 1')
    return cb()
}

const Antes2 = cb => {
    console.log('Tarefa Antes 2')
    return cb()
}

function Copiar(cb)
{
    // gulp.src(['pastaA/arquivo1.txt', 'pastaA/arquivo2.txt'])
    gulp.src('pastaA/**/*.txt')
        .pipe(gulp.dest('pastaB'))
    return cb()
} 

const Fim = cb => {
    console.log('Tarefa Fim')
    return cb()
}

module.exports.default = series(parallel(Antes1, Antes2), Copiar, Fim)