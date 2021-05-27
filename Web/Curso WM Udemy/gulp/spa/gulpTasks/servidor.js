const gulp = require('gulp')
const webServer = require('gulp-webserver')
const watch = require('gulp-watch')

function Servidor()
{
    return gulp.src('build')
        .pipe(webServer({
            port: 8080,
            open: true,
            livereload: true,
        }))
}

function MonitorarArquivos(cb)
{
    watch('src/**/*.html', function() {gulp.series('AppHTML')()})
    // watch('src/**/*.scss', () => gulp.series('appCSS')())
    // watch('src/**/*.js', () => gulp.series('appJS')())
    // watch('src/assets/imgs/**/*.*', () => gulp.series('appIMG')())
    return cb()
}

module.exports = {
    MonitorarArquivos,
    Servidor
}