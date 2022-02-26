function buildSubmitValuesforGrid(gridHandle, keyPreix) {
    var input;
    var allKeyValues = [];
    var allGridColumns = gridHandle.columns;
    var gridDS = gridHandle.dataSource;
    var gridData = gridHandle.dataSource.view();

    if (gridData.length > 0) {
        for (var i = 0; i < gridData.length; i++) {
            for (var j = 0; j < allGridColumns.length; j++) {
                if (allGridColumns[j].field != undefined) {
                    var propName = keyPreix + "(" + i + ")." + allGridColumns[j].field;

                    var fieldDataType = gridDS.options.schema.model.fields[allGridColumns[j].field].type;
                    if (fieldDataType === "date") {
                        var propValue = kendo.toString(gridData[i][allGridColumns[j].field], "MM/dd/yyyy");
                    }
                    else {
                        var propValue = gridData[i][allGridColumns[j].field];
                    }

                    input = $("<input>", { type: 'hidden', name: propName, value: propValue });
                    allKeyValues.push($(input));
                }
            }
        }
    }

    return allKeyValues;
}