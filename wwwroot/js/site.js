// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

class Counter {
    constructor(quill, options) {
        this.quill = quill;
        this.options = options;
        this.container = document.querySelector(options.container);
        quill.on('text-change', this.update.bind(this));
        this.update();
    };

    calculate() {
        let text = this.quill.getText();
        if (this.options.unit === 'word') {
            text = text.trim();
            return text.length > 0 ? text.split(/\s+/).length : 0;
        } else {
            return text.length - 1;
        }
    }

    update() {
        var length = this.calculate();
        var label = this.options.unit;
        if (length !== 1) {
            label += 's';
        }
        this.container.innerText = length + ' ' + label;
    }
}

var toolbarOptions = [
    ['bold', 'italic', 'underline', 'strike'],
    [{ 'list': 'bullet' }, { 'list': 'ordered' }],
    [{ 'indent': '-1' }, { 'indent': '+1' }],
    [{ 'align': [] }],
    ['blockquote', 'code-block'],
    ['link', 'video', 'image']
];

Quill.register('modules/counter', Counter);

var quill = new Quill('#editor', {
    modules: {
        toolbar: toolbarOptions,
        counter: {
            container: '#counter',
            unit: 'character'
        }
    },

    theme: 'snow'
});