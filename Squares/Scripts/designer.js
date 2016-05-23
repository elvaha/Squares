var cc = function (options, images) {

    var squareSize;

    var rowSize = 0;
    var colSize = 0;



    var minRowSize = minColSize = options.minGridSize !== undefined ? options.minGridSize : 2;
    var maxRowSize = maxColSize = options.maxGridSize !== undefined ? options.maxGridSize : 5;
    var gridSize = options.initialGridSize !== undefined ? options.initialGridSize : 3;

    var rootElem = $(options.container);

    var dragZone = $(rootElem).find(options.dragzone).first();
    var dropZone = $(rootElem).find(options.dropzone).first();

    function emptyDropZone() {

        $(options.dropboxWrapper).remove();

        return this;

    }

    function initializeSquareGrid() {

        if (options.debugMode)
            var COLOR = getRandomColor();

        rowSize = colSize = gridSize;

        for (var i = 0; i < (rowSize * colSize) ; i++) {

            newElem = newDropBox();

            if (options.debugMode)
                $(newElem).find(options.dropbox).css('background-color', COLOR);

            dropZone.append(newElem);

            boxWidth(newElem);
            boxHeight(newElem.find(options.dropbox));

        }

        return this;

    }

    function initializeDragBox() {

        $(images).each(function (i, e) {

            var newElem = newDragBox(e);

            dragZone.append(newElem);

            boxHeight(newElem);

        });

        return this;

    }

    function boxWidth(element) {

        $(element).css('width', (100 / colSize) + '%');
        squareSize = $(element).width();
        return element;

    }

    function getBoxSize() {
        return squareSize;
    }

    function boxHeight(element) {

        $(element).height($(element).width());
        return element;

    }

    function toggleDropZoneGutter() {

        $(options.dropboxWrapper).toggleClass('gutter');

        return this;

    }

    function newDropBox() {

        var newGutterWrapper = $('<div></div>');
        newGutterWrapper
			.addClass('dropbox-wrapper');

        var rotatorBtn = $('<button>R</button>');
        $(rotatorBtn).addClass('rotator');

        $(rotatorBtn).click(function () {

            var imgArray = $(this).parent().find('img');

            if (imgArray.length === 1) {

                var imageTarget = $(imgArray[0]);
                var rotationValue = parseInt(imageTarget.attr('data-rotation'));

                rotationValue = (rotationValue + 90) % 360;

                $(imageTarget).css('transform', 'rotate(' + rotationValue + 'deg)');
                $(imageTarget).attr('data-rotation', rotationValue);

            }

        });

        $(newGutterWrapper).hover(function () {

            $(rotatorBtn).show();

        }, function () {

            $(rotatorBtn).hide();

        });

        var newDropBoxElem = $('<div></div>');
        newDropBoxElem
			.addClass('dropbox');

        newGutterWrapper
			.append(newDropBoxElem);

        newGutterWrapper.append(rotatorBtn);

        return newGutterWrapper;
    }

    function newDragBox(source) {

        var newWrapper = $('<div></div>');
        newWrapper
			.addClass('dragbox-wrapper');

        var newDragBoxElem = $('<img />');
        newDragBoxElem
			.attr('src', source)
			.addClass('dragbox')
			.attr('data-rotation', 0)
			.attr('data-isplaced', 'no');

        newWrapper
			.append(newDragBoxElem);

        return newWrapper;

    }

    function createRow(position) {

        if (rowSize === maxRowSize)
            return this;

        if (options.debugMode)
            var COLOR = getRandomColor();

        for (var i = 0; i < colSize; i++) {

            newElem = newDropBox();

            if (options.debugMode)
                $(newElem).find(options.dropbox).css('background-color', COLOR);

            if (position)
                dropZone.append(newElem);
            else
                dropZone.prepend(newElem);

            boxWidth(newElem);
            boxHeight(newElem.find(options.dropbox));

        }

        rowSize++;

        return this;

    }

    function deleteRow(position) {

        if (minRowSize === rowSize)
            return this;

        var itemArray = $(options.dropzone).children(options.dropboxWrapper);

        var start;
        var end;

        if (position) {

            start = itemArray.length - colSize;
            end = itemArray.length;

        } else {

            start = 0;
            end = start + colSize;

        }

        for (start; start < end; start++) {

            $(itemArray[start]).remove();

        }

        rowSize--;

        return this;

    }

    function createColumn(position) {

        if (maxColSize === colSize)
            return this;

        if (options.debugMode)
            var COLOR = getRandomColor();

        colSize++;
        var itemArray = $(dropZone).children(options.dropboxWrapper);
        var newElem;

        itemArray.each(function (i, e) {

            boxWidth(e);
            boxHeight($(e).find(options.dropbox));

            if ((i + 1) % (colSize - 1) === 0) {

                newElem = newDropBox();

                if (options.debugMode)
                    $(newElem).find(options.dropbox).css('background-color', COLOR);

                $(newElem).insertAfter(e);

                boxWidth(newElem);
                boxHeight(newElem.find(options.dropbox));

            }

        });

        if (!position) {

            $(newElem).detach();
            $(dropZone).prepend(newElem);

        }

        return this;

    }

    function deleteColumn(position) {

        if (minColSize === colSize)
            return this;

        colSize--;
        var itemArray = $(dropZone).children(options.dropboxWrapper);

        itemArray.each(function (i, e) {

            boxWidth(e);
            boxHeight($(e).find(options.dropbox));

            if ((i + 1) % (colSize + 1) === 0) {

                if (position)
                    $(itemArray[i])
						.remove();
                else
                    $(itemArray[i])
						.next()
						.remove();

            }

        });

        if (!position)
            $(itemArray[0]).remove();

        return this;

    }

    var getRandomColor = function () {

        var letters = '0123456789ABCDEF'.split('');
        var color = '#';

        for (var i = 0; i < 6; i++) {
            color += letters[Math.floor(Math.random() * 16)];
        }

        return color;

    }

    return {
        getBoxSize: getBoxSize,
        initializeSquareGrid: initializeSquareGrid,
        newDropBox: newDropBox,
        createRow: createRow,
        deleteRow: deleteRow,
        createColumn: createColumn,
        deleteColumn: deleteColumn,
        emptyDropZone: emptyDropZone,
        toggleDropZoneGutter: toggleDropZoneGutter,
        initializeDragBox: initializeDragBox
    }

}

var myCC = new cc({

    container: '#myCreator',
    dragzone: '.drag-zone',
    dropzone: '.drop-zone',
    dropboxWrapper: '.dropbox-wrapper',
    dropbox: '.dropbox',
    gridbutton: '.grid-button',
    initialGridSize: 3,
    minGridSize: 2,
    maxGridSize: 5,
    debugMode: false,

}, []);

myCC.emptyDropZone().initializeSquareGrid();

interact('.corner', {}).draggable({

    onmove: function (event) {

        var target = event.target,
		// keep the dragged position in the data-x/data-y attributes
		x = (parseFloat(target.getAttribute('data-x')) || 0) + event.dx,
		y = (parseFloat(target.getAttribute('data-y')) || 0) + event.dy;

        // translate the element
        target.style.webkitTransform =
		target.style.transform =
		'translate(' + x + 'px, ' + y + 'px)';

        // update the posiion attributes
        target.setAttribute('data-x', x);
        target.setAttribute('data-y', y);

    },

    onend: function (event) {

        var corner = event.target;

        switch ($(corner).attr('id')) {

            case 'top-left':

                if (event.dx > 25 & event.dy > 25) {

                    myCC.deleteRow(false).deleteColumn(false);

                } else if (event.dx < -25 & event.dy < -25) {

                    myCC.createRow(false).createColumn(false);

                }

                break;

            case 'top-right':

                if (event.dx < -25 & event.dy > 25) {

                    myCC.deleteRow(false).deleteColumn(true);

                } else if (event.dx > 25 & event.dy < -25) {

                    myCC.createRow(false).createColumn(true);

                }

                break;

            case 'bottom-left':

                if (event.dx > 25 & event.dy < -25) {

                    myCC.deleteRow(true).deleteColumn(false);

                } else if (event.dx < -25 & event.dy > 25) {

                    myCC.createRow(true).createColumn(false);

                }

                break;

            case 'bottom-right':

                if (event.dx < -25 & event.dy < -25) {

                    myCC.deleteRow(true).deleteColumn(true);

                } else if (event.dx > 25 & event.dy > 25) {

                    myCC.createRow(true).createColumn(true);

                }

                break;

        }

        event.target.setAttribute('data-x', 0);
        event.target.setAttribute('data-y', 0);
        event.target.style.transform = 'none';

    }

});

interact('.dragbox', {}).draggable({

    onstart: function (event) {

        var target = event.target;

        $(target).css('padding', '0');
        $(target).css('width', myCC.getBoxSize());
        $(target).css('height', myCC.getBoxSize());

    },

    onmove: function (event) {

        var target = event.target,
		// keep the dragged position in the data-x/data-y attributes
		x = (parseFloat(target.getAttribute('data-x')) || 0) + event.dx,
		y = (parseFloat(target.getAttribute('data-y')) || 0) + event.dy;

        // translate the element
        target.style.webkitTransform =
		target.style.transform =
		'translate(' + x + 'px, ' + y + 'px)';

        // update the posiion attributes
        target.setAttribute('data-x', x);
        target.setAttribute('data-y', y);

    },

    onend: function (event) {

        $(event.target).removeAttr('style');
        $(event.target).css('padding', '0');
        event.target.setAttribute('data-x', 0);
        event.target.setAttribute('data-y', 0);
        event.target.style.transform = 'none';

    }

});

interact('.dropbox').dropzone({
    // only accept elements matching this CSS selector
    accept: '.dragbox',
    // Require a 50% element overlap for a drop to be possible
    overlap: 0.5,

    // listen for drop related events:

    ondropactivate: function (event) {

    },
    ondragenter: function (event) {

    },
    ondragleave: function (event) {

    },
    ondrop: function (event) {

        var draggableElement = event.relatedTarget,
			dropzoneElement = event.target;

        if ($(dropzoneElement).children().length === 0) {

            var a = $(draggableElement).attr('data-isplaced');

            if ($(draggableElement).attr('data-isplaced') === 'yes') {

                $(draggableElement).detach();
                $(dropzoneElement).append(draggableElement);

            } if ($(draggableElement).attr('data-isplaced') === 'no') {

                var dragParent = $(draggableElement).parent();
                var clone = $(draggableElement).clone();
                $(clone).attr('style', 'none');

                $(draggableElement).detach();
                $(dropzoneElement).append(draggableElement);
                $(draggableElement).attr('data-isplaced', 'yes');

                $(dragParent).append(clone);
                $(clone).attr('data-x', 0);
                $(clone).attr('data-y', 0);

            }


        }


    },
    ondropdeactivate: function (event) {

    }
});