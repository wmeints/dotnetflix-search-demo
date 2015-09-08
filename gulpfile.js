var gulp = require('gulp');
var bower = require('gulp-bower');
var sass = require('gulp-ruby-sass');
var sourcemaps = require('gulp-sourcemaps');

/**
 * Restores packages in the build
 */
gulp.task('restore-packages', function() {
  return bower().pipe(gulp.dest('wwwroot/bower_components'));
});

/**
 * Compiles the SASS files into proper CSS
 */
gulp.task('compile-sass', function() {
  var config = {
    style: 'compressed',
    sourcemap: true,
    loadPath: [
      'bower_components/bootstrap-sass/assets/stylesheets'
    ]
  };

  return sass('Styles/', config)
    .on('error', sass.logError)
    .pipe(sourcemaps.write())
    .pipe(gulp.dest('wwwroot/css'));
});
