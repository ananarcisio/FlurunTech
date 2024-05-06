<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Atualizar alunos</title>
</head>
<body>
    <section id="cardcontainer">
    <div class="card">
    

    <?php
    //Dados de conexao
    $hostname = "localhost";
    $username = "root";
    $password = "";
    $database = "bdeventos";
    $resultado;
    
    //conectar
    try {
        $conn = new mysqli($hostname, $username, $password, $database);
    } catch (Exception $e) {
        die("<div id='title' role='alert'>Erro ao conectar: " . $e->getMessage() . "</div>");
    }

    //Inserir dados no banco

    if (empty($_POST['razaosocial']) ||empty($_POST['nomefantasia']) || empty($_POST['email']) || empty($_POST['telefone']) || empty($_POST['cnpj']) || empty($_POST['endereco']) || empty($_POST['numero']) || empty($_POST['complemento']) || empty($_POST['bairro']) || empty($_POST['cidade']) || empty($_POST['uf']) || empty($_POST['setor'])) {
        
        $id = $_POST['id'];
        $razaosocial = $_POST['razaosocial'];
        $nomefantasia = $_POST['nomefantasia'];
        $email = $_POST['email'];
        $telefone = $_POST['telefone'];
        $cnpj = $_POST['cnpj'];
        $endereco = $_POST['endereco'];
        $numero = $_POST['numero'];
        $complemento = $_POST['complemento'];
        $bairro = $_POST['bairro'];
        $cidade = $_POST['cidade'];
        $estado = $_POST['UF'];
        $setor = $_POST['setor'];
        
        $sql = "UPDATE fornecedores SET razaosocial ='$razaosocial', nomefantasia ='$nomefantasia', email ='$email', telefone ='$telefone', cnpj ='$cnpj', endereco ='$endereco', numero ='$numero', complemento ='$complemento', bairro ='$bairro', cidade='$cidade', estado ='$estado', setor ='$setor' where id = $id";         
        try {
            $resultado = $conn->query($sql);
        }
        catch (Exception $e) {
            echo "Erro ao atualizar os dados";
        }
       
    }

    ?>

    <?php if ($resultado) : ?>
        <div id="title" role="alert">
            Dados atualizados com sucesso!
        </div>
    <?php else : ?>
        <div id="title" role="alert">
            Erro ao atualizar o dado!
        </div>
    <?php endif ?>

        <a href="dados.php"> <button  type="button"> Ver fornecedores </button></a>
    </div>
    </section>
</body>
</html>

<style>
  body{
    background-color: #000;
    padding: 5vh;
    font-family: 'Segoe UI', sans-serif;
    color: white;
  }
  #title{
    grid-column: span 2;
    background: linear-gradient(-45deg, #fc00ff 0%, #00dbde 100%);
    color: white; 
    font-size: 2rem;
    justify-self: center;
    width: 100%;
    border-radius: 7px;
    text-align: center;
  }
  #cardcontainer{
   display: flex;
   width: 100%;
   height: 100%;
   align-items: center;
   justify-content: center;
  }
  .card {
    position: relative;
    width: 50vw;
    height: 85vh;
    background-color: #000;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    padding: 12px;
    gap: 12px;
    border-radius: 8px;
    cursor: pointer;
    color: white;
    gap: 50%;
  }
  .card::before {
    content: '';
    position: absolute;
    inset: 0;
    left: -10px;
    margin: auto;
    width: 53vw;
    height: 92vh;
    border-radius: 10px;
    background: linear-gradient(-45deg, #e81cff 0%, #40c9ff 100% );
    z-index: -10;
    pointer-events: none;
    transition: all 0.6s cubic-bezier(0.175, 0.885, 0.32, 1.275);
  }

  .card::after {
    content: "";
    z-index: -1;
    position: absolute;
    inset: 0;
    background: linear-gradient(-45deg, #fc00ff 0%, #00dbde 100% );
    transform: translate3d(0, 0, 0) scale(0.95);
    filter: blur(20px);
  }

  .card p:not(.heading) {
    font-size: 14px;
  }

  .card p:last-child {
    color: #e81cff;
    font-weight: 600;
  }

  .card:hover::after {
    filter: blur(30px);
  }

  .card:hover::before {
    transform: rotate(-90deg) scaleX(1.34) scaleY(0.77);
  }

button {
 --color: #560bad;
 font-family: inherit;
 display: inline-block;
 width: 8em;
 height: 2.6em;
 line-height: 2.3em;
 margin: 20px;
 position: relative;
 overflow: hidden;
 border: 2px solid var(--color);
 transition: color .5s;
 z-index: 1;
 font-size: 17px;
 border-radius: 20px;
 font-weight: 500;
 color: var(--color);
 background-color: rgba(86, 11, 173, 20%);
}

button:before {
 content: "";
 position: absolute;
 z-index: -1;
 background: var(--color);
 height: 150px;
 width: 200px;
 border-radius: 50%;
}

button:hover {
 color: #fff;
}

button:before {
 top: 100%;
 left: 100%;
 transition: all .7s;
}

button:hover:before {
 top: -30px;
 left: -30px;
}

button:active:before {
 background: #3a0ca3;
 transition: 0s;
}

</style>