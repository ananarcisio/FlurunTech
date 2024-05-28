<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Fornecedores cadastrados</title>
</head>
<body>
    <?php
        //dados de conexão
        $hostname = "localhost";
        $username = "root";
        $password = "";
        $database = "bdeventos";

        //Conectar
        $conn = new mysqli($hostname, $username, $password, $database);

        if ($conn->error) {
            die("Erro ao conectar $conn->error");
        }

        //Preparei a qyery
        $sql = "SELECT * FROM contratantes";

        //Executar a query
        $resultado = $conn->query($sql);
    ?>
    <section id="cardcontainer">
    <div class="card">
        <h1 id="title">Contratantes cadastrados</h1>
        <table class="gradient-table">
            <thead>
                <tr>
                    <th>Empresa</th>
                    <th>E-mail</th>
                    <th>Telefone</th>
                    <th>Cargo</th>
                    <th>Nome</th>
                    <th>Alterar</th>
                    <th>Excluir</th>
                </tr>
            </thead>
            <tbody>
            <?php
            foreach ($resultado as $linha) {

            ?>
                <tr>
                    <td><?php echo $linha['empresa'] . '<br>'; ?></td>
                    <td><?php echo $linha['email'] . '<br>'; ?></td>
                    <td><?php echo $linha['telefone'] . '<br>'; ?></td>
                    <td><?php echo $linha['cargo'] . '<br>'; ?></td>
                    <td><?php echo $linha['nome'] . '<br>'; ?></td>
                    <td>
                        <a href="update.php?id=<?=$linha['id']?>&empresa=<?=$linha['empresa']?>&email=<?=$linha['email']?>&telefone=<?=$linha['telefone']?>&cargo=<?=$linha['cargo']?>&nome=<?=$linha['nome']?>">
                            <button class="tooltip">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="#6361D9" class="bi bi-pencil" viewBox="0 0 16 16">
                                    <path d="M12.146.146a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1 0 .708l-10 10a.5.5 0 0 1-.168.11l-5 2a.5.5 0 0 1-.65-.65l2-5a.5.5 0 0 1 .11-.168zM11.207 2.5 13.5 4.793 14.793 3.5 12.5 1.207zm1.586 3L10.5 3.207 4 9.707V10h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.293zm-9.761 5.175-.106.106-1.528 3.821 3.821-1.528.106-.106A.5.5 0 0 1 5 12.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.468-.325"/>
                                </svg>
                            </button>
                        </a>
                    </td> 
                    <td>
                        <a href="delete.php?id=<?= $linha['id'] ?>">
                        <button class="tooltip">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 20 20" height="25" width="25">
                                <path fill="#6361D9" d="M8.78842 5.03866C8.86656 4.96052 8.97254 4.91663 9.08305 4.91663H11.4164C11.5269 4.91663 11.6329 4.96052 11.711 5.03866C11.7892 5.11681 11.833 5.22279 11.833 5.33329V5.74939H8.66638V5.33329C8.66638 5.22279 8.71028 5.11681 8.78842 5.03866ZM7.16638 5.74939V5.33329C7.16638 4.82496 7.36832 4.33745 7.72776 3.978C8.08721 3.61856 8.57472 3.41663 9.08305 3.41663H11.4164C11.9247 3.41663 12.4122 3.61856 12.7717 3.978C13.1311 4.33745 13.333 4.82496 13.333 5.33329V5.74939H15.5C15.9142 5.74939 16.25 6.08518 16.25 6.49939C16.25 6.9136 15.9142 7.24939 15.5 7.24939H15.0105L14.2492 14.7095C14.2382 15.2023 14.0377 15.6726 13.6883 16.0219C13.3289 16.3814 12.8414 16.5833 12.333 16.5833H8.16638C7.65805 16.5833 7.17054 16.3814 6.81109 16.0219C6.46176 15.6726 6.2612 15.2023 6.25019 14.7095L5.48896 7.24939H5C4.58579 7.24939 4.25 6.9136 4.25 6.49939C4.25 6.08518 4.58579 5.74939 5 5.74939H6.16667H7.16638ZM7.91638 7.24996H12.583H13.5026L12.7536 14.5905C12.751 14.6158 12.7497 14.6412 12.7497 14.6666C12.7497 14.7771 12.7058 14.8831 12.6277 14.9613C12.5495 15.0394 12.4436 15.0833 12.333 15.0833H8.16638C8.05588 15.0833 7.94989 15.0394 7.87175 14.9613C7.79361 14.8831 7.74972 14.7771 7.74972 14.6666C7.74972 14.6412 7.74842 14.6158 7.74584 14.5905L6.99681 7.24996H7.91638Z" clip-rule="evenodd" fill-rule="evenodd"></path>
                            </svg>
                        </button>
                        </a>
                    </td> 
                </tr>
            <?php
            }
            ?>
            </tbody>
        </table>
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
    display: flexbox;
    align-items: center;
    justify-items: center;
  }
  #title{
    grid-column: span 2;
    background: linear-gradient(-45deg, #fc00ff 0%, #00dbde 100%);
    color: black; 
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
    width: 90%;
    height: 85%;
    background-color: #000;
    display: flex;
    flex-direction: column;
    align-self: center;
    justify-self: center;
    justify-content: center;
    align-items: center;
    padding: 12px;
    border-radius: 8px;
    cursor: pointer;
    color: white;
  }
  .card::before {
    content: '';
    position: absolute;
    inset: 0;
    left: -10px;
    margin: auto;
    width: 102%;
    height: 107%;
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
 display: flex;
 flex-direction: column;
 justify-content: center;
 align-items: center;
 padding: 1em;
 border: 0px solid transparent;
 background-color: rgba(100,77,237,0.08);
 border-radius: 1.25em;
 transition: all 0.2s linear;
}

button:hover {
 box-shadow: 3.4px 2.5px 4.9px rgba(0, 0, 0, 0.025),
  8.6px 6.3px 12.4px rgba(0, 0, 0, 0.035),
  17.5px 12.8px 25.3px rgba(0, 0, 0, 0.045),
  36.1px 26.3px 52.2px rgba(0, 0, 0, 0.055),
  99px 72px 143px rgba(0, 0, 0, 0.08);
}

.tooltip {
 position: relative;
 display: inline-block;
}

.tooltip .tooltiptext {
 visibility: hidden;
 width: 4em;
 background-color: rgba(0, 0, 0, 0.253);
 color: #fff;
 text-align: center;
 border-radius: 6px;
 padding: 5px 0;
 position: absolute;
 z-index: 1;
 top: 25%;
 left: 110%;
}

.tooltip .tooltiptext::after {
 content: "";
 position: absolute;
 top: 50%;
 right: 100%;
 margin-top: -5px;
 border-width: 5px;
 border-style: solid;
 border-color: transparent rgba(0, 0, 0, 0.253) transparent transparent;
}

.tooltip:hover .tooltiptext {
 visibility: visible;
}

.gradient-table {
    border-collapse: separate; /* Usar bordas separadas */
    width: 100%;
    border: 2px solid white; /* Borda branca para a tabela */
    border-spacing: 0; /* Espaçamento entre as células */
}

.gradient-table td, .gradient-table th {
    padding: 8px;
    text-align: left;
    color: white;
    border: 1px solid white; /* Borda branca para as células */
}

.gradient-table tr {
    border-bottom: 1px solid white; /* Borda branca para as linhas */
}

.gradient-table tr:last-child {
    border-bottom: none; /* Remover a borda inferior da última linha */
}

.gradient-table tr td:last-child {
    border-right: none; /* Remover a borda direita das células da última coluna */
}

.gradient-table tr:first-child {
    border-top: 1px solid white; /* Borda branca para a primeira linha */
}

.gradient-table tr th {
    background-color: rgba(0, 0, 0, 0.5); /* Cor de fundo para o cabeçalho */
}

.gradient-table tr:nth-child(even) {
    background-color: rgba(0, 0, 0, 0.2); /* Cor de fundo para linhas pares */
}

.gradient-table tr:nth-child(odd) {
    background-color: rgba(0, 0, 0, 0.1); /* Cor de fundo para linhas ímpares */
}


</style>