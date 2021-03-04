UID_LOCAL        ?= "$(shell id -u)"
GID_LOCAL        ?= "$(shell id -g)"
APP_DIR           = app
IMAGE_BUILD       = microsoft/dotnet


create.zip:
	@cd ${PWD}/${APP_DIR}/release && zip -r9 $(PROJECT_NAME).zip *
	@mv ${PWD}/${APP_DIR}/release/$(PROJECT_NAME).zip ./
	@ls -al ${PWD}/${APP_DIR}/release/

upload.zip:
	aws s3 cp ./$(PROJECT_NAME).zip s3://$(INFRA_BUCKET)/$(LAMBDA_FUNCTION_S3_KEY)