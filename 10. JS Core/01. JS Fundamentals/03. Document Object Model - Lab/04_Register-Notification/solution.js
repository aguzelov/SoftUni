function register() {
  let userNameInputElement = document.getElementById('username');
  let emailInputElement = document.getElementById('email');
  let passwordInputElement = document.getElementById('password');

  let username = userNameInputElement.value;
  let email = emailInputElement.value;
  let password = passwordInputElement.value;

  let emailRegex = new RegExp('(.+)@(.+).(com|bg)');

  if (username && password && email.match(emailRegex)) {
    let resultElement = document.getElementById('result');

    let headerElemment = document.createElement('h1');
    headerElemment.textContent = 'Successful Registration!';
    resultElement.appendChild(headerElemment);

    resultElement.innerHTML += `Username: ${username}<br>`;
    resultElement.innerHTML += `Email: ${email}<br>`;
    resultElement.innerHTML += `Password: ${"*".repeat(password.length)}`;
    setTimeout(function () {
      resultElement.innerHTML = '';
    }, 5000);
  }
}
