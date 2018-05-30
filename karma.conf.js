// Karma configuration
// Generated on Thu May 24 2018 16:36:14 GMT+0300 (Belarus Standard Time)

module.exports = function(config) {
  config.set({

    // base path that will be used to resolve all patterns (eg. files, exclude)
    basePath: '',

    // frameworks to use
    // available frameworks: https://npmjs.org/browse/keyword/karma-adapter
    frameworks: ['jasmine','browserify'],

    // list of files / patterns to load in the browser
    files: [
      'FileSystemTests/spec/javascripts/helpers/jasmine-jquery.js',
      'FileSystemTests/spec/javascripts/helpers/jquery.js',
      'FileSystemTests/Javascript/test.js',
       'FileSystemTests/Javascript/ChangePasswordViewTest.js'
    ],


    // list of files / patterns to exclude
    exclude: [
    ],


    // preprocess matching files before serving them to the browser
    // available preprocessors: https://npmjs.org/browse/keyword/karma-preprocessor
    preprocessors: {
      'FileSystemTests/Javascript/*.js': [ 'browserify' ]
    },
 
    helpers:{   
    },

    // test results reporter to use
    // possible values: 'dots', 'progress'
    // available reporters: https://npmjs.org/browse/keyword/karma-reporter
    reporters: ['progress'],


    // web server port
    port: 9876,


    // enable / disable colors in the output (reporters and logs)
    colors: true,


    // level of logging
    // possible values: config.LOG_DISABLE || config.LOG_ERROR || config.LOG_WARN || config.LOG_INFO || config.LOG_DEBUG
    logLevel: config.LOG_INFO,


    // enable / disable watching file and executing tests whenever any file changes
    autoWatch: true,


    // start these browsers
    // available browser launchers: https://npmjs.org/browse/keyword/karma-launcher
    browsers: ['Chrome'],


    // Continuous Integration mode
    // if true, Karma captures browsers, runs the tests and exits
    singleRun: false,

    browserify: {
      debug: true,
      transform: [ 'brfs' ]
    },

    // Concurrency level
    // how many browser should be started simultaneous
    concurrency: Infinity
  })
}
