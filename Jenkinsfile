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
        choices: ['DEFAULT', 'DEPLOY_STACK', 'UPDATE_FUNCTION', 'DELETE_STACK']
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
          when {
            expression {
              params.EXECUTE == 'DEPLOY_STACK' || params.EXECUTE == 'UPDATE_FUNCTION'
            }
          }
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
            when { expression { return params.EXECUTE == 'UPDATE_FUNCTION' } }
            steps {
                echo 'Update Function ...'
            }
        }
        stage('Delete Stack') {
            when { expression { return params.EXECUTE == 'DELETE_STACK' } }
            steps {
                echo 'Delete Stack..'
            }
        }
    }
}