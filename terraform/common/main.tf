terraform {
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 3.0"
    }
  }

  backend "s3" {
    bucket = "terraform-applications"
    key    = "4blocks/terraform.tfstate"
    region = "us-east-1"
  }
}

provider "aws" {
  region  = "us-east-1"
}

data "terraform_remote_state" "operation" {
  backend = "s3"
  config = {
    bucket = "terraform-operations"
    key    = "${var.operation}/terraform.tfstate"
    region = "us-east-1"
  }
}

resource "aws_route53_record" "elb_dns" {
  zone_id = data.terraform_remote_state.operation.outputs.hosted_zone.id
  name    = "4blocks.${var.operation}.${var.organization}.com."
  type    = "CNAME"
  ttl     = "60"
  records = [var.elb_dns_name]
}
