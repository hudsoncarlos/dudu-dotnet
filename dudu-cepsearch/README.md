# Consulta de Endereço por CEP - Desafio Técnico para Desenvolvedor de Software Sênior

## Visão Geral:

Este projeto foi desenvolvido como parte de um desafio técnico para a vaga de Desenvolvedor de Software Sênior. A principal funcionalidade da aplicação web consiste em permitir que os usuários consultem informações de endereço com base em um CEP fornecido. Para isso, a aplicação integra-se à API ViaCep, armazena os dados retornados em um banco de dados e exibe as informações detalhadas na tela.

## Requisitos e Tecnologias Utilizadas:

### Tecnologias:

- **.NET 5**: O projeto foi desenvolvido utilizando o framework .NET 5, garantindo performance, segurança e escalabilidade.
- **API ViaCep**: Utilizada para consultar informações de endereço com base no CEP fornecido pelo usuário.

### Funcionalidades:

1. **Interface de Usuário Intuitiva**: A aplicação web oferece uma interface amigável onde os usuários podem inserir um CEP específico para consulta.
  
2. **Integração com API ViaCep**: Ao receber um CEP válido, a aplicação realiza uma requisição GET para a API ViaCep, obtendo informações detalhadas sobre o endereço associado ao CEP fornecido.
  
3. **Armazenamento de Dados**: Os dados retornados pela API são armazenados de forma estruturada em um banco de dados, garantindo a persistência e a disponibilidade das informações consultadas.
  
4. **Exibição de Informações**: Após a consulta e o armazenamento dos dados, a aplicação exibe as informações detalhadas do endereço na tela, proporcionando uma visualização clara e organizada para o usuário.

### Exemplo de Requisição ViaCep:

Para realizar a consulta, a aplicação utiliza uma requisição GET à API ViaCep, seguindo o formato padrão:
```
https://viacep.com.br/ws/{CEP}/json/
```
Substituindo `{CEP}` pelo valor fornecido pelo usuário.

## Conclusão:

Este projeto demonstra minha capacidade de desenvolver soluções práticas, eficientes e escaláveis utilizando tecnologias modernas como .NET 5. Ao abordar o desafio proposto para a vaga de Desenvolvedor de Software Sênior, busquei não apenas atender aos requisitos funcionais, mas também aplicar melhores práticas de desenvolvimento, garantindo a qualidade, a segurança e a performance da aplicação.

Agradeço pela oportunidade de participar deste desafio técnico e estou à disposição para discutir qualquer aspecto adicional do projeto ou para avançar para etapas subsequentes do processo seletivo.
