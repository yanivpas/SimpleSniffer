#include "stdafx.h"
#include "pcap.h"
#include "packet_parser.h"
#define TIMEOUT 1000

void packet_handler(char *user, struct pcap_pkthdr *h,
                    const char *bytes) 
{
    char *data;
    struct connection conn;
    char tcp_flags;
    char *bla;
    printf("packet handler is claled \n");
    get_tcp_data((char*)bytes, h->len, &conn, &tcp_flags, &data);
    if (data != NULL) {
		printf("len: %d\n", bytes + h->len - data);
        for (;data < (bytes+h->len); data++) {
            putchar(*data);
        }
    }
}

void blabla(void)
{
    char errbuf[PCAP_ERRBUF_SIZE];
    pcap_t *pcap;
    int ret_value = -1;
    pcap_if_t *interface_ = NULL;

    ret_value = pcap_findalldevs(&interface_, errbuf);
    if (-1 == ret_value) {
        printf("%s\n", errbuf);
        return;
    }
	pcap = pcap_open_live(interface_->name, 1000, 0, TIMEOUT, errbuf);
	if (NULL == pcap) {
		printf("%s\n", errbuf);
		return;
	}
    for (; interface_ != NULL; interface_ = interface_->next) {
        printf("%s\n", interface_->name);
    }

  
    pcap_loop(pcap, -1, (pcap_handler)packet_handler, (u_char*)"me");
}
