const wrapper = document.querySelector(".wrapper");
const defaultBtn = document.querySelector("#default-btn");
const customBtn = document.querySelector("#custom-btn");
const img = document.querySelector("img");
const cancelBtn = document.querySelector("#cancel-btn");
const fileName = document.querySelector(".file-name");
let regExp = /[0-9a-zA-Z\^\&\'\@\{\}\[\]\,\$\=\!\-\#\(\)\.\%\+\~\_ ]+$/;

customBtn.addEventListener('click', function (e) {
    e.preventDefault();
    defaultBtn.click();
});

defaultBtn.addEventListener('change', function (e) {
    const file = this.files[0];

    if (file) {
        const reader = new FileReader();
        reader.onload = function (e) {
            const result = reader.result;
            img.src = result;
            wrapper.classList.add("active");
        }
        cancelBtn.addEventListener('click', function (e) {
            img.src = "";
            wrapper.classList.remove(".active");
        });
        reader.readAsDataURL(file);
    }
    if (this.value) {
        let valueStore = this.value.match(regExp);
        fileName.textContent = valueStore;
    }
});