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
                  fnSteps.build_application(params.ENVIRONMENT)
                }
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}