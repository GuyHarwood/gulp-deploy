"use strict";

let gulp = require('gulp'),
    msbuild = require('gulp-msbuild'),
    nunit = require('gulp-nunit-runner'),
    runSequence = require('run-sequence'),
    configTransform = require('gulp-config-transform'),
    sc = require('windows-service-controller'),
    _ = require('underscore'),
    deployConfig = require('./deploy/deploy.json'),
    components = require('./deploy/components.json'),
    q = require('q'),
    iis = require('iis'),
    yargs = require('yargs')
    .usage('Usage: $0 -buildVersion [major.minor.patch]')
    //.demand(['buildVersion'])
    .argv;

    gulp.task('default', function(done){
        console.log('hello from gulp');
        done();
    })