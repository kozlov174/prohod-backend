terraform {
  required_providers {
    yandex = {
      source = "yandex-cloud/yandex"
    }
  }
  required_version = ">= 0.13" #изменить версию тф на актуальную 
}

provider "yandex" {
  zone = "<зона_доступности_по_умолчанию>" ## добавить зону доступности
}

resource "yandex_compute_instance" "backend" {
  name = "backend"
  
}
resource "yandex_compute_instance" "database" {
  name = "database"
}