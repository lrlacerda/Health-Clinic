# Health Clinic - Sistema de Gestão Clínica

**Descrição:**

Health Clinic é um sistema web desenvolvido para auxiliar a gestão de uma clínica médica, permitindo o cadastro de pacientes, agendamento de consultas, gerenciamento de médicos e muito mais. A aplicação visa simplificar a administração da clínica e melhorar o atendimento aos pacientes.

## Funcionalidades Principais:

### Perfis de Usuário:

1. **Administrador:** Colaboradores da área administrativa da clínica.
2. **Médico:** Profissionais da área da saúde.
3. **Paciente:** Clientes da clínica.

### Funcionalidades:

1. **Cadastro de Usuários:** O administrador pode cadastrar usuários com diferentes perfis (administrador, médico ou paciente).

2. **Agendamento de Consultas:** O administrador pode agendar consultas, especificando o paciente, data do agendamento e o médico responsável.

3. **Cancelamento de Consultas:** O administrador tem a capacidade de cancelar agendamentos de consultas.

4. **Cadastro de Clínica:** Informações da clínica, como endereço, horário de funcionamento, CNPJ, nome fantasia e razão social, podem ser registradas pelo administrador.

5. **Visualização de Consultas:** Médicos podem ver as consultas agendadas associadas a eles.

6. **Registro de Prontuário:** Médicos podem incluir descrições de consultas, vinculadas ao paciente.

7. **Visualização de Consultas:** Pacientes podem visualizar suas próprias consultas.

## Sprint 1 - Banco de Dados:

O banco de dados foi modelado para suportar todas as funcionalidades da aplicação, incluindo informações sobre médicos, pacientes, consultas e muito mais. A modelagem abrange os modelos conceitual, lógico e físico.

## Sprint 2 - Back-End (API):

A aplicação é baseada em uma API que oferece endpoints para todas as funcionalidades mencionadas. A autenticação é realizada por meio de tokens JWT (JSON Web Token), e a autorização é baseada nas funções de cada usuário.

### Endpoints Disponíveis:

1. `/login`: Autenticação.
2. `/medicos`: Lista de médicos.
3. `/pacientes`: Lista de pacientes.
4. `/consultas`: Cadastro de consulta e listagem (todas / somente de um paciente / somente de um médico).
5. `/documentacao`: Documentação da API.

## Sprint 3 - Front-End (ReactJS):

A interface do usuário foi desenvolvida usando o ReactJS e integra-se à API para fornecer uma experiência de usuário amigável e intuitiva.

### Telas:

- **Administrador:** Interface para gerenciar usuários, agendamentos e dados da clínica.
- **Médico:** Visualização de consultas e registro de prontuário.
- **Paciente:** Visualização das próprias consultas.

## Sprint 4 - Deploy:

A aplicação foi implantada em um domínio público, tornando-a acessível a partir de qualquer lugar via internet.

## Sprint 5 - IA (Inteligência Artificial):

Foi implementada uma funcionalidade de moderação de conteúdo usando o serviço Content Moderator da Microsoft Azure. Isso garante que os comentários dos pacientes sejam exibidos somente se não contiverem palavras impróprias.

**Tecnologias Utilizadas:**

- Back-End: Node.js, Express.js, MongoDB.
- Front-End: ReactJS.
- Banco de Dados: MongoDB.
- Autenticação: JSON Web Tokens (JWT).
- Serviço de IA: Microsoft Azure Content Moderator.

**Instruções de Uso:**

1. Clone este repositório.
2. Configure as variáveis de ambiente necessárias (por exemplo, informações de conexão com o banco de dados, segredo JWT).
3. Execute `npm install` nas pastas do back-end e front-end para instalar as dependências.
4. Inicie o servidor back-end e o aplicativo front-end.
5. Acesse a aplicação pelo navegador.

**Autores:**

- Lucas Lacerda

**Licença:**

Este projeto é licenciado sob a Licença MIT - consulte o arquivo [LICENSE](LICENSE) para obter detalhes.

**Agradecimentos:**





