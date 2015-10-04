/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = '/AssetsCPro/Admin/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/AssetsCPro/Admin/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/AssetsCPro/Admin/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/AssetsCPro/AdminCPr/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Data';
    config.filebrowserFlashUploadUrl = '/AssetsCPro/Admin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    CKFinder.setupCKEditor(null, '/AssetsCPro/Admin/ckfinder/');
};

