variable "organization" {
  type        = string
  description = "Organization name. Must be DNS-compliant."
}

variable "operation" {
  type        = string
  description = "Operation name; prototypical scopes include dev, stage, and production 'environments'. Must be DNS-compliant."
}

variable "elb_dns_name" {
  type        = string
  description = "DNS name of the target ELB to create a CNAME record."
}
