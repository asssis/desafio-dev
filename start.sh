docker stop desafio_dev

docker container rm -f desafio_dev

docker rmi -f desafio_dev

docker build --tag desafio_dev .

docker run --name desafio_dev -d -p 3000:3000 -p 3001:3001 desafio_dev