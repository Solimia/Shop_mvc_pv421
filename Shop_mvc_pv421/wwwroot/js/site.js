// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function configConfirmModal(dialogId, confirmUrl) {
    var modal = document.getElementById(dialogId)
    var deleteBtn = modal.querySelector('.actionBtn')

    modal.addEventListener('show.bs.modal', function (event) {

        var button = event.relatedTarget
        // ----id
        var id = button.getAttribute('data-bs-id')
        // var deleteBtn = modal.querySelector('.modal #deleteBtn')
        deleteBtn.setAttribute('href', confirmUrl + id)
    })
}