pipeline {
    agent any
  parameters {
    choice(
      name: 'ENVIRONMENT',
      choices: ['dev', 'pre', 'prod']
    )
    choice(
      name: 'EXECUTE',
      choices: ['DEFAULT', 'DEPLOY_STACK', 'UPDATE_FUNCTION']
    )
  }
    stages {
        stage('Build') {
            steps {
                echo 'Building..'
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