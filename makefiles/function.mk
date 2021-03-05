UID_LOCAL        ?= "$(shell id -u)"
GID_LOCAL        ?= "$(shell id -g)"
APP_DIR           = app
IMAGE_BUILD       = mcr.microsoft.com/dotnet/core/sdk

build:
	dotnet publish /${APP_DIR}/src/serverless-apirest/serverless-apirest.csproj -o /${APP_DIR}/release

create.zip:
	@cd ${PWD}/${APP_DIR}/release && zip -r9 $(PROJECT_NAME).zip *
	@mv ${PWD}/${APP_DIR}/release/$(PROJECT_NAME).zip ./

upload.zip:
	aws s3 cp ./$(PROJECT_NAME).zip s3://$(INFRA_BUCKET)/$(LAMBDA_FUNCTION_S3_KEY)