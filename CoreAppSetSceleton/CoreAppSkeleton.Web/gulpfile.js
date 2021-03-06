﻿/// <binding AfterBuild='copy' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/
"use strict";

var gulp = require("gulp"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify");

var paths = {
    webroot: "./wwwroot/"
};

paths.bootstrapCss = "./bower_components/bootstrap/dist/css/bootstrap.css";
paths.bootstrapThemeCss = "./bower_components/bootswatch/superhero/bootstrap.css";

paths.jqueryJs = "./bower_components/jquery/dist/jquery.js";
paths.jqueryValidationJs = "./bower_components/jquery-validation/dist/jquery.validate.js";
paths.jqueryValidationUnobtrusiveJs = "./bower_components/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js";
paths.bootstrapJs = "./bower_components/bootstrap/dist/js/bootstrap.js";
paths.bootboxJs = "./bower_components/bootbox.js/bootbox.js";

paths.jsDest = paths.webroot + "js";
paths.cssDest = paths.webroot + "css";
paths.fontDest = paths.webroot + "fonts";

gulp.task("min:js", function () {
    return gulp.src([
            paths.jqueryJs,
            paths.bootstrapJs,
            paths.bootboxJs
        ])
        .pipe(concat(paths.jsDest + "/min/site.min.js"))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

// Made so we can invoke validation only if needed where needed
gulp.task("min:js:validation", function () {
    return gulp.src([
            paths.jqueryValidationJs,
            paths.jqueryValidationUnobtrusiveJs
        ])
        .pipe(concat(paths.jsDest + "/min/validation.min.js"))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("copy:js", function () {
    return gulp.src([
            paths.jqueryJs,
            paths.jqueryValidationJs,
            paths.jqueryValidationUnobtrusiveJs,
            paths.bootstrapJs,
            paths.bootboxJs
        ])
        .pipe(gulp.dest(paths.jsDest));
});

gulp.task("min:css", function () {
    return gulp.src([paths.bootstrapCss, paths.bootstrapThemeCss])
        .pipe(concat(paths.cssDest + "/min/site.min.css"))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("copy:css", function () {
    return gulp.src([paths.bootstrapCss, paths.bootstrapThemeCss])
        .pipe(gulp.dest(paths.cssDest));
});

gulp.task("min", ["min:js", "min:js:validation", "min:css"]);
gulp.task("copy", ["copy:js", "copy:css"])