function limparCampos() {
    document.getElementById('nome').value = '';
    document.getElementById('descricao').value = '';
    document.getElementById('tamanho').value = '';
    document.getElementById('quantidade').value = '';
    document.getElementById('preco').value = '';
}

function limparTela() {
    limparCampos();
    document.getElementById('mensagem').textContent = '';
}

async function cadastrarProduto() {
    const token = localStorage.getItem('token');
    const mensagem = document.getElementById('mensagem');
    const btnCadastrar = document.getElementById('btnCadastrar');
    btnCadastrar.disabled = true;

    const precoInput = document.getElementById('preco').value.replace(',', '.');
    const preco = parseFloat(precoInput);

    if (isNaN(preco)) {
        mensagem.textContent = 'Preço inválido. Use números como 30.00 ou 30,00.';
        mensagem.style.color = 'red';
        btnCadastrar.disabled = false;
        return;
    }

    const produto = {
        nome: document.getElementById('nome').value,
        descricao: document.getElementById('descricao').value,
        tamanho: document.getElementById('tamanho').value,
        quantidade: parseInt(document.getElementById('quantidade').value),
        preco: preco
    };

    try {
        const response = await fetch('http://localhost:5176/api/produtos', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify(produto)
        });

        if (response.ok) {
            mensagem.textContent = 'Produto cadastrado com sucesso!';
            mensagem.style.color = 'green';
            limparCampos();
        } else {
            mensagem.textContent = 'Erro ao cadastrar produto.';
            mensagem.style.color = 'red';
        }
    } catch (error) {
        mensagem.textContent = 'Erro de conexão com o servidor.';
        mensagem.style.color = 'red';
    }

    btnCadastrar.disabled = false;
}

async function atualizarProduto(id) {
    const token = localStorage.getItem('token');
    const mensagem = document.getElementById('mensagem');

    const precoInput = document.getElementById('preco').value.replace(',', '.');
    const preco = parseFloat(precoInput);

    if (isNaN(preco)) {
        mensagem.textContent = 'Preço inválido.';
        mensagem.style.color = 'red';
        return;
    }

    const produto = {
        id: id,
        nome: document.getElementById('nome').value,
        descricao: document.getElementById('descricao').value,
        tamanho: document.getElementById('tamanho').value,
        quantidade: parseInt(document.getElementById('quantidade').value),
        preco: preco
    };

    try {
        const response = await fetch(`http://localhost:5176/api/produtos/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify(produto)
        });

        if (response.ok) {
            mensagem.textContent = 'Produto atualizado com sucesso!';
            mensagem.style.color = 'green';
        } else {
            mensagem.textContent = 'Erro ao atualizar produto.';
            mensagem.style.color = 'red';
        }
    } catch (error) {
        mensagem.textContent = 'Erro de conexão com o servidor.';
        mensagem.style.color = 'red';
    }
}

async function excluirProduto(id) {
    const token = localStorage.getItem('token');
    const mensagem = document.getElementById('mensagem');

    try {
        const response = await fetch(`http://localhost:5176/api/produtos/${id}`, {
            method: 'DELETE',
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });

        if (response.ok) {
            mensagem.textContent = 'Produto excluído com sucesso!';
            mensagem.style.color = 'green';
        } else {
            mensagem.textContent = 'Erro ao excluir produto.';
            mensagem.style.color = 'red';
        }
    } catch (error) {
        mensagem.textContent = 'Erro de conexão com o servidor.';
        mensagem.style.color = 'red';
    }
}

function voltar() {
    window.location.href = '/Produto/Index';
}
