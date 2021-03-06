.DEFAULT_GOAL := help

## APP VARS ##
PRODUCT       = iprovider ##Indica el nombre del producto
FUNCTION      = lab ##Indica el nombre del caso de uso

## PARAMS VARS
DEPLOY_REGION      = us-east-2 # region aws
COGNITO_USER_GROUP = arn:aws:cognito-idp:us-east-2:432499991508:userpool/us-east-2_Kf22M5zA0

## GENERAL VARS ##
ENV                     ?= lab ## nombre del ambiente a desplegar
INFRA_BUCKET             = infraestructura-labs ## Nombre del del bucket s3 
PROJECT_NAME             = $(PRODUCT)-$(ENV)-fn-$(FUNCTION) ## Nombre del proyecto
LAMBDA_FUNCTION_S3_KEY   = build/lambda/$(ENV)/$(PROJECT_NAME).zip

## INCLUDE TARGETS ##
-include makefiles/*.mk
