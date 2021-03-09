stack.deploy:
	aws cloudformation deploy \
	--template-file ./cloudformation/template.yaml \
	--stack-name $(PROJECT_NAME) \
	--parameter-overrides \
		SourceFunctionBucket=$(INFRA_BUCKET) \
		SourceFunctionKey=$(LAMBDA_FUNCTION_S3_KEY) \
		ProjectName=$(PROJECT_NAME) \
		CognitoUserGroup=$(COGNITO_USER_GROUP) \
	--capabilities CAPABILITY_NAMED_IAM \
	--region $(DEPLOY_REGION)