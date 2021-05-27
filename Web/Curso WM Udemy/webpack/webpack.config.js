const modoDev = process.env.NODE_ENV !== 'production'

const { Module } = require('webpack')
const Webpack = require('webpack')
const MiniCssExtractPlugin = require('mini-css-extract-plugin')
//const UglifyJsPlugin = require('uglifyjs-webpack-plugin')
const OptimizeCssAssetsPlugin = require('optimize-css-assets-webpack-plugin')
const TerserPlugin = require('terser-webpack-plugin') //PRA USAR NO LUGAR DO UGLIFYJS

module.exports = {
    mode: modoDev ? 'development' : 'production',
    entry: './src/principal.js',
    output: {
        filename: 'principal.js',
        path: __dirname + '/public'
    },
    devServer: {
        contentBase: './public',
        port: 9000
    },
    optimization: {
        minimizer: [
            new TerserPlugin({
                parallel: true,
                terserOptions: {
                    ecma: 6,
                },
            }),
            new OptimizeCssAssetsPlugin({})
        ]
    },
    plugins: [
        new MiniCssExtractPlugin({
            filename: 'estilo.css'
        })
    ],
    module: {
        rules: [{
                test: /\.s?[ac]ss$/,
                use: [
                    MiniCssExtractPlugin.loader,
                    //'style-loader', //ADICIONA CSS A DOM INJETANDO A TAG <style>
                    'css-loader', //INTERPRETA @import, url()...
                    'sass-loader',

                ]
            },
            {
              test: /\.(png|svg|jpg|gif)$/,
              use: ['file-loader']  
            }
            
        ]
    }
}