function readTableToArr() {
    var arr = [];
    var JsData = "";

    $("#roleTable tbody tr").each(function (index, data) {

        const roleId = $(data).find(".tId").text();
        const roleName = $(data).find(".tName").text();
        const useRole = $(data).find(".tCheck").is(":checked");

        arr.push({
            roleId: roleId,
            roleName: roleName,
            useRole: useRole
        });
    });
    return JSON.stringify(arr);
}

function updateJsonFile() {

    $("#jsonRoles").val(readTableToArr());
}