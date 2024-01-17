O projeto foi desenvolvido utilizando DDD como padrão de projeto e com princípios SOLID.
A versão do .net foi a 6.0, enityframework e code-first.

A solution contem 6 projetos, sendo eles:

1. Application - é a aplicação, sendo uma WEBAPI, ela que receberá requisições do usuário. 
2. Service - é responsável por receber da aplicação fazer o desenvolvimento lógico.
3. Data - é responsável  pelos repositórios aonde é  feita a busca de dados na base, aonde também guarda as migrations.
4. Domain -  aonde é mantida nossas entidades, dtos e interface de contratos.
5. CrossCutting - aonde é configurado a injeção de dependência, mapeamentos dos dtos.
6. Tests - aonde é realizado os testes unitários e de integração.


Breve comentários sobre algumas classes:
BaseRepository: classe desenvolvida para realizar crud genéricos, ou seja, toda entidade que será acrescentada na aplicação poderá utiliza-la apenas implementando o IRepository.

ProductRepository: O repositorio do produto foi criado apenas para suprir dois métodos específicos que vamos ter apenas na entidade produto, se fosse utilizada na classe base estaríamos obrigando futuras entidades a implementar métodos não necessários infligindo princípios do SOLID. Então ele herda o crud básico do BaseRepository e faz sua implementações.  

DTOS em geral: Para exemplo criei uma coluna chamada CreateAt e UpdateAt que armazena informações apenas quando é criado ou atualizado um produto, os DTOS foram criados para não exibir essas informações ou ser um campo necessário ao usuário já que estes campos são para uso interno da aplicação.
