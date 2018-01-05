/*
Copyright (c) 2003-2009, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.fullBasePath = "/Administrator";
CKEDITOR.editorConfig = function( config )
{
	
    config.toolbar_Basic =
    [

	   ['Font','FontSize','Find', 'Replace','Seperator', 'Cut', 'Copy', 'Paste', 'Undo', 'Redo', 'Bold', 'Italic', 'Underline', 'Strike', 'NumberedList', 'BulletedList', 'Image', 'SpecialChar','Link','Unlink', 'Source', 'Maximize', 'Preview']

    ];
    config.toolbar = 'Basic';
    config.filebrowserImageBrowseUrl = CKEDITOR.fullBasePath + "/CKEditor/ImageBrowser"; //CKEDITOR.basePath + "ImageBrowser.aspx";
    config.filebrowserImageWindowWidth = 780;
    config.filebrowserImageWindowHeight = 720;
    //config.filebrowserBrowseUrl = CKEDITOR.fullBasePath + "/CKEditor/LinkBrowser";
    config.filebrowserWindowWidth = 500;
    config.filebrowserWindowHeight = 650;
    
};
