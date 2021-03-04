UID_LOCAL        ?= "$(shell id -u)"
GID_LOCAL        ?= "$(shell id -g)"
APP_DIR           = app
IMAGE_BUILD       = mcr.microsoft.com/dotnet/core/sdk

build:
	docker container run --env DOTNET_CLI_HOME=/tmp/ \
		--workdir "/${APP_DIR}" --rm -i \
		-u ${UID_LOCAL}:${GID_LOCAL} \
		-v "${PWD}/${APP_DIR}":/${APP_DIR} \
		${IMAGE_BUILD} \
		dotnet publish /${APP_DIR}/src/serverless-apirest/serverless-apirest.csproj -o /${APP_DIR}/release

create.zip:
	@cd ${PWD}/${APP_DIR}/release && zip -r9 $(PROJECT_NAME).zip *
	@mv ${PWD}/${APP_DIR}/release/$(PROJECT_NAME).zip ./
	@ls -al ${PWD}/${APP_DIR}/release/

upload.zip:
	aws s3 cp ./$(PROJECT_NAME).zip s3://$(INFRA_BUCKET)/$(LAMBDA_FUNCTION_S3_KEY)