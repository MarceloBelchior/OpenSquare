var gulp = require('gulp'),
    uglify = require('gulp-uglify'),
    cssmin = require('gulp-cssmin'),
    rename = require('gulp-rename'),
    sass = require('gulp-sass'),
    path = require('path'),
    gutil = require("gulp-util"),
    less = require('gulp-less');

gulp.task('copy:lib', function () {
    gulp.src('node_modules/@angular/**/*.js').pipe(gulp.dest('./wwwroot/lib/npm/@angular/'));
    gulp.src('node_modules/angular2-in-memory-web-api/**/*.js').pipe(gulp.dest('./wwwroot/lib/npm/angular2-in-memory-web-api/'));
    gulp.src('node_modules/bootstrap/dist/**/*').pipe(gulp.dest('./wwwroot/lib/npm/bootstrap/'));
    gulp.src('node_modules/systemjs/**/*.js').pipe(gulp.dest('./wwwroot/lib/npm/systemjs/'));
    gulp.src('node_modules/rxjs/**/*.js').pipe(gulp.dest('./wwwroot/lib/npm/rxjs/'));
    gulp.src('node_modules/jquery/**/*.js').pipe(gulp.dest('./wwwroot/lib/npm/jquery/'));
    gulp.src('node_modules/es6-shim/**/*.js').pipe(gulp.dest('./wwwroot/lib/npm/es6-shim/'));
    gulp.src('node_modules/zone.js/**/*.js').pipe(gulp.dest('./wwwroot/lib/npm/zone.js/'));
    gulp.src('node_modules/reflect-metadata/**/*.js').pipe(gulp.dest('./wwwroot/lib/npm/reflect-metadata/'));
    gulp.src('node_modules/symbol-observable/**/*.js').pipe(gulp.dest('./wwwroot/lib/npm/symbol-observable/'));


    gulp.src('node_modules/font-awesome/fonts/*').pipe(gulp.dest('./wwwroot/lib/css/font-awesome/fonts/'));
    gulp.src('node_modules/font-awesome/css/*').pipe(gulp.dest('./wwwroot/lib/css/font-awesome/css/'));
    gulp.src('node_modules/animate.css/*.css').pipe(gulp.dest('./wwwroot/lib/css/animate.css/'));
    gulp.src('node_modules/normalize.css/normalize.css').pipe(gulp.dest('./wwwroot/lib/css/normalize.css/'));
    gulp.src('node_modules/Ionicons/css/*').pipe(gulp.dest('./wwwroot/lib/css/Ionicons/css/'));
    gulp.src('node_modules/Ionicons/fonts/*').pipe(gulp.dest('./wwwroot/lib/css/Ionicons/fonts/'));

    gulp.src('node_modules/fastclick/lib/fastclick.js').pipe(gulp.dest('./wwwroot/lib/npm/fastclick/'));
    gulp.src('node_modules/slimScroll/jquery.slimscroll.js').pipe(gulp.dest('./wwwroot/lib/npm/slimScroll/'));

//    gulp.src('node_modules/Ionicons/css/*').pipe(gulp.dest('./wwwroot/lib/npm/Ionicons/css/'));
 //   gulp.src('node_modules/Ionicons/fonts/').pipe(gulp.dest('./wwwroot/lib/npm/Ionicons/fonts/'));
    //gulp.src('node_modules/nprogress/nprogress.js').pipe(gulp.dest('./wwwroot/lib/npm/nprogress/'));
    //node_modules\Ionicons
});
gulp.task('less:skins', function () {
    gulp.src('./build/less/skins/*.less')
    .pipe(less())
    .pipe(gulp.dest('wwwroot/css/skins/'));
});
gulp.task('less:skin', function () {
    gulp.src('./build/less/AdminLTE.less')
    .pipe(less())
    .pipe(gulp.dest('wwwroot/css/'));
});

gulp.task('default', ['less']);
gulp.task('less', function () {
    return gulp.src('./build/**/*.less')
      .pipe(less({
          paths: [path.join(__dirname, 'less', 'includes')]
      }))
      .pipe(gulp.dest('./wwwroot/Content/css'));
});
//gulp.task('styles:XX', function () {
//    gulp.src('./Sass/ge/*.scss')
//      .pipe(sass())
//      .pipe(gulp.dest('./wwwroot/lib/css/custon.css'));

//});



//var sassOptions = {
//    errLogToConsole: true,
//    outputStyle: 'expanded'
//};

//gulp.task('sass', function () {
//    return gulp
//      .src('/content/initial.scss')
//      .pipe(sass(sassOptions))
//      .pipe(gulp.dest('./wwwroot/css/'));
//});
//gulp.task("sass:x", function () {
//    return gulp.src('./wwwroot/Content/flat/scss/**/*.scss')
//      .pipe(sass())
//      .pipe(gulp.dest('./wwwroot/css/'));
//});
//gulp.task("scss", function () {
//    return gulp.src('./wwwroot/Content/*.scssc')
//          .pipe(scss(
//          { "bundleExec": true }
//      )).pipe(gulp.dest("./wwwroot/css/"));
//});
//gulp.task('sass:ruby', function () {
//    sass_2('./wwwroot/Content/theme.scssc', { sourcemap: true })
//        .on('error', sass.logError)
//        // for inline sourcemaps
//        .pipe(sourcemaps.write())
//        // for file sourcemaps
//        .pipe(sourcemaps.write('maps', {
//            includeContent: false,
//            sourceRoot: 'source'
//        }))
//        .pipe(gulp.dest('./wwwroot/css/'));
//});

////gulp.task('sass', function () {
////    return gulp.src('./wwwroot/**/**/*.scss')
////      .pipe(sass().on('error', sass.logError))
////      .pipe(gulp.dest('./wwwroot/css'));
////});

////gulp.task('copy-min-js', function () {
////    _.forEach(js, function (file, _) {
////        gulp.src(file)
////            .pipe(uglify())
////            .pipe(rename({ extname: '.min.js' }))
////            .pipe(gulp.dest('./wwwroot/js'))
////    });
////    _.forEach(angularJs, function (file, _) {
////        gulp.src(file)
////            .pipe(uglify())
////            .pipe(rename({ extname: '.min.js' }))
////            .pipe(gulp.dest('./wwwroot/js/angular2'))
////    });
////});

////gulp.task('copy-css', function () {
////    _.forEach(css, function (file, _) {
////        gulp.src(file)
////            .pipe(gulp.dest('./wwwroot/css'))
////    });
////    _.forEach(fonts, function (file, _) {
////        gulp.src(file)
////            .pipe(gulp.dest('./wwwroot/fonts'))
////    });
////});

////gulp.task('copy-min-css', function () {
////    _.forEach(css, function (file, _) {
////        gulp.src(file)
////            .pipe(cssmin())
////            .pipe(rename({ extname: '.min.css' }))
////            .pipe(gulp.dest('./wwwroot/css'))
////    });
////    _.forEach(fonts, function (file, _) {
////        gulp.src(file)
////            .pipe(gulp.dest('./wwwroot/fonts'))
////    });
////});

////gulp.task('default', ['copy-js', 'copy-css']);
////gulp.task('minify', ['copy-min-js', 'copy-min-css']);
////gulp.task('default', function () {
////    // place code for your default task here
////});





//gulp.task('styles', function () {
//    return gulp.src('./wwwroot/Content/*.scss')
//      .pipe(sass({ errlogtoconsole: true }))
//      .pipe(sass({
//          style: 'expanded',
//          sourcecomments: 'normal'
//      }))
//      .pipe(gulp.dest('./wwwroot/css'));
//});

//gulp.task('styles-dev', function () {
//    return gulp.src('./wwwroot/app/initial.scss')
//      .pipe(sass({
//          debugInfo: true,
//          lineNumbers: true,
//          loadPath: './wwwroot/app',
//          style: 'expanded'
//      }))
//      .pipe(gulp.dest('./wwwroot/css'));
//});