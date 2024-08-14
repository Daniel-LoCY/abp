$(function () {

    let createModal = new abp.ModalManager(abp.appPath + 'Books/CreateModal');
    let table = $('#list_books')

    createModal.onResult(function (e) {
        let response = arguments[1].responseText;
        let rows = table.find('tr');
        rows.remove();
        response.forEach(item => {
            let row = `<tr>
                <td>${item.bookname}</td>
                <td>${item.price}</td>
            </tr>`;
            table.append(row);
        });
    }
    );

    $('#NewBookButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

});
