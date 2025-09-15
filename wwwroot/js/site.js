window.fazerLogin = function () {
    const email = document.getElementById("email").value;
    const senha = document.getElementById("senha").value;
    const mensagem = document.getElementById("mensagem");

    if (email === "admin@avanade.com" && senha === "123456") {
        mensagem.textContent = "";
        window.location.href = "/Tarefa/Painel";
    } else {
        mensagem.textContent = "E-mail ou senha inválidos.";
    }
}

function entrar() {
    window.location.href = "/Tarefa/Login"; // ou a rota correta da sua página de login
}

function sair() {
    window.location.href = "/"; // ou para a página de login
}


