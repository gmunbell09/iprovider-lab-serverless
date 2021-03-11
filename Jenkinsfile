def fnSteps = evaluate readTrusted("jenkinsfiles/steps.groovy")

pipeline {
    agent any
    parameters {
      choice(
        name: 'ENVIRONMENT',
        choices: ['lab', 'dev']
      )
      choice(
        name: 'EXECUTE',
        choices: ['DEFAULT', 'DEPLOY_STACK', 'UPDATE_FUNCTION']
      )
    }
    stages {
        stage('Setting') {
            steps {
                script {
                  config = fnSteps.configs(params.ENVIRONMENT)
                }
            }
        }
        stage('Build') {
            steps {
                script {
                  fnSteps.build_application(config)
                }
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy Stack') {
            when { expression { return params.EXECUTE == 'DEPLOY_STACK' } }
            steps {
                script {
                  fnSteps.stack_deploy(config)
                }
            }
        }
        stage('Update Function') {
            steps {
                echo 'Update Function ...'
            }
        }
        stage('Delete Stack') {
            steps {
                echo 'Delete Stack..'
            }
        }
    }
}