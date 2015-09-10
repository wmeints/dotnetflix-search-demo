# dotnetflix-search-demo
Demo application for the DotNetFlix episode on ElasticSearch.


## Quick start
Please make sure you have DNVM and a DNX runtime installed. 
To see how, please refer to [the ASP.NET home repository](https://github.com/aspnet/home)

This demo makes use of the ruby sass compiler. To compile the sources, please have ruby 2.0 installed on your 
machine. You can download the version for your machine from [http://rubyinstaller.org/](http://rubyinstaller.org/) for Windows.
For Mac I recommended the use of [The Ruby Version Manager](http://rvm.io/)

To run the demo, execute the following script:

``` shell
gem install sass
npm -g install gulp
npm install
bower install
dnu restore
```

## Compiling the sources
To compile the demo sources, please use the following commands:

``` shell
gulp compile-sass
dnu build
```
