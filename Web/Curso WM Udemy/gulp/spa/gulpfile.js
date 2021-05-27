const { series, parallel } = require('gulp')
const gulp = require('gulp')

const { AppHTML, AppCSS, AppJS, AppIMG } = require('./gulpTasks/app')
const { DepsCSS, DepsFonts } = require('./gulpTasks/deps')
const {MonitorarArquivos, Servidor } = require('./gulpTasks/servidor')

module.exports.default = series(
    parallel(
        series(AppHTML, AppCSS, AppJS, AppIMG),
        series(DepsCSS, DepsFonts)
    ),
    Servidor,
    MonitorarArquivos
)