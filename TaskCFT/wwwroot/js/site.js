// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function setIdToInput() {
    var val = $('#applicationInput').val()
    var options = $('#applicationsList').find('option')

    var matchedOption = null
    
    options.each(function () {
        if ($(this).val() === val) {
            matchedOption = $(this)
            return false
        }
    })

    if (matchedOption != null) {
        var label = matchedOption.attr('label')
        $('#appId').val(label)
    } else {
        $('#appId').val(-1)
    }
    
}
