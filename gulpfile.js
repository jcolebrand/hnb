'use strict';

const gulp = require('gulp');
const debug = require('gulp-debug')
const sass = require('gulp-sass');
const notify = require('gulp-notify');
const uglifycss = require('gulp-uglifycss');
const ext_replace = require('gulp-ext-replace');
const sourcemaps = require('gulp-sourcemaps');

const isDebugEnabled = true;

gulp.task('scss', function () {
  return gulp.src('hnb/Styles/**/*.scss')
    .pipe(sourcemaps.init())
    .pipe(sass())
    .on("error", notify.onError(function (error) {
      return "File: " + error.message;
    }))
    .pipe(debug({ title: 'CSS |' }))
    .pipe(gulp.dest('./hnb/Styles'))
    .pipe(uglifycss())
    .pipe(ext_replace('.min.css'))
    .pipe(sourcemaps.write('.'))
    .pipe(gulp.dest('./hnb/Styles'))
    .pipe(notify("SCSS task finished"));
});

gulp.task('watch', function () {
  gulp.watch('hnb/Styles/**/*.scss', ['scss']);
});

gulp.task('default', ['watch']);