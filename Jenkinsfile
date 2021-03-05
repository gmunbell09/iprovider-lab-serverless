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
        stage('Build') {
            steps {
                script {
                  sh 'make build'
                  sh 'make create.zip'
                  sh 'make upload.zip'
                }
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            when { expression { return params.EXECUTE == 'DEPLOY_STACK' } }
            steps {
                escript {
                  sh 'make stack.deploy'
                }
            }
        }
    }
}