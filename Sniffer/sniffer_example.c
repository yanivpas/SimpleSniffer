#include <pcap/pcap.h>
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
    get_tcp_data(bytes, h->len, &conn, &tcp_flags, &data);
    if (data != NULL) {
        for (;data < (bytes+h->len); data++) {
            putchar(*data);
        }
    }
}

void main(void)
{
    char errbuf[PCAP_ERRBUF_SIZE];
    pcap_t *pcap;
    int ret_value = -1;
    pcap_if_t *interface = NULL;

    ret_value = pcap_findalldevs(&interface, errbuf);
    if (-1 == ret_value) {
        printf("%s\n", errbuf);
        return;
    }

    for (; interface != NULL; interface = interface->next) {
        printf("%s\n", interface->name);
    }

    pcap = pcap_open_live("lo", 1000, 0, TIMEOUT, errbuf);
    if (NULL == pcap) {
        printf("%s\n", errbuf);
        return;
    }
    pcap_loop(pcap, -1, packet_handler, "me");
}
