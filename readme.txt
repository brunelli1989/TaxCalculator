Como o projeto esta organizado?
	Todos os projetos estão dentro da "src" por questões de organização;
	O projeto utiliza o basico de um projeto DDD - Domain Driven Design;
	Possui um projeto para entrada de dados do tipo console: "TaxCalculator";
	Possui o projeto "TaxCalculator.ApiModels" onde são armazenados os contratos externos. As ApiModels podem ser empacotadas para serem reutizadas como contratos de API no futuro;
	O "TaxCalculator.Domain" é o dominio onde possui a regra de negocio. O core do sistema;
	"TaxCalculator.Test" serve para testar diversas parte do sistema. Neste projeto so testa o dominio.

Bibliotecas
	O projeto utiliza um pacote externo chamado Newtonsoft para manipular JSON.
	Foi instalado um outro pacote externo chamado AutoMapper para mapear um objeto em outro. É muito util em projetos com API.

Requisitos
	.Net 3.1 ou superior ( https://docs.microsoft.com/pt-br/dotnet/core/tools/dotnet-install-script#recommended-version )
	
Como executar o codigo?
	Visual Studio:
		É necessario abrir o arquivo "TaxCalculator.sln" definir o projeto inicial: "TaxCalculator" e em seguida apertar F5 ou o botão de "play" com o nome do projeto.
	
	VSCode
		É necessario abrir o arquivo "TaxCalculator.sln". Vá no terminal, entre na pasta "src\TaxCalculator" e digite "dotnet run".
		
	Sem IDE
		Vá até a pasta "src\TaxCalculator". 
			Digite "dotnet run" e cole/informe os valores no formato JSON;
		    ou via cmd TaxCalculator.exe '[{\"operation\":\"buy\", \"unit-cost\":10, \"quantity\": 10000}, {\"operation\":\"sell\", \"unit-cost\":20, \"quantity\": 5000}]'
			ou via powershell .\TaxCalculator.exe '[{\"operation\":\"buy\", \"unit-cost\":10, \"quantity\": 10000}, {\"operation\":\"sell\", \"unit-cost\":20, \"quantity\": 5000}]'
			ou apenas dotnet run '[{\"operation\":\"buy\", \"unit-cost\":10, \"quantity\": 10000}, {\"operation\":\"sell\", \"unit-cost\":20, \"quantity\": 5000}]'
		
			