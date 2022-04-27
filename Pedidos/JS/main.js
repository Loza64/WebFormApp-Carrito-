const signUpButtom = document.getElementById('signUp');
const signInButtom = document.getElementById('signIn');
const container = document.getElementById('container');

signUpButtom.addEventListener('click', () => {
    container.classList.add('right-panel-active');
});

signInButtom.addEventListener('click', () => {
    container.classList.remove('right-panel-active');
});